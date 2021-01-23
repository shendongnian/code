    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Omu.ValueInjecter;
    
    namespace MySystem.Services.Mapping
    {
        // the static mapper class
        public static class Mapper
        {
            private static IList<ObjectContainer> _objects;
    
            //map source to an existing target
            public static TTarget Map<TSource, TTarget>(TSource source, TTarget target)
            {
                target = MapperFactory.GetMapper<TSource, TTarget>().Map(source, target);
                return target;
            }
    
            //create a new target and map source on it 
            public static TTarget Map<TSource, TTarget>(TSource source)
            {
                _objects = new List<ObjectContainer>();
                var target = (TTarget)Creator.Create(typeof(TTarget));
                var obj = MapperFactory.GetMapper<TSource, TTarget>().Map(source, target);
                _objects.Add(new ObjectContainer()
                                 {
                                     original = source,
                                     converted = obj
                                 });
                return obj;
            }
    
            public static object Map(object source, object target, Type sourceType, Type targetType)
            {
                target = target ?? Creator.Create(targetType);
                var getMapper = typeof(MapperFactory).GetMethod("GetMapper").MakeGenericMethod(sourceType, targetType);
                var mapper = getMapper.Invoke(null, null);
                var map = mapper.GetType().GetMethod("Map");
                var obj = map.Invoke(mapper, new[] { source, target });
                _objects.Add(new ObjectContainer()
                                 {
                                     original = source,
                                     converted = obj
                                 });
                return obj;
            }
    
            public static object MapFinal(object source, object target, Type sourceType, Type targetType)
            {
                foreach (var obj in _objects)
                {
                    if (source.Equals(obj.original))
                    {
                        return obj.converted;
                    }
                }
                return null;
            }
        }
    
        public class ObjectContainer
        {
            public object original { get; set; }
            public object converted { get; set; }
        }
    
        public static class MapperFactory
        {
            private static readonly IDictionary<Type, object> Mappers = new Dictionary<Type, object>();
    
            public static ITypeMapper<TSource, TTarget> GetMapper<TSource, TTarget>()
            {
                //if we have a specified TypeMapper for <TSource,Target> return it
                if (Mappers.ContainsKey(typeof(ITypeMapper<TSource, TTarget>)))
                    return Mappers[typeof(ITypeMapper<TSource, TTarget>)] as ITypeMapper<TSource, TTarget>;
    
                //if both Source and Target types are Enumerables return new EnumerableTypeMapper<TSource,TTarget>()
                if (typeof(TSource).IsEnumerable() && typeof(TTarget).IsEnumerable())
                {
                    return (ITypeMapper<TSource, TTarget>)Activator.CreateInstance(typeof(EnumerableTypeMapper<,>).MakeGenericType(typeof(TSource), typeof(TTarget)));
                }
    
                //return the default TypeMapper
                return new TypeMapper<TSource, TTarget>();
            }
    
            public static void AddMapper<TS, TT>(ITypeMapper<TS, TT> o)
            {
                Mappers.Add(typeof(ITypeMapper<TS, TT>), o);
            }
    
            public static void ClearMappers()
            {
                Mappers.Clear();
            }
        }
    
        public interface ITypeMapper<TSource, TTarget>
        {
            TTarget Map(TSource source, TTarget target);
        }
    
        public class TypeMapper<TSource, TTarget> : ITypeMapper<TSource, TTarget>
        {
            public virtual TTarget Map(TSource source, TTarget target)
            {
                target.InjectFrom(source);
                target.InjectFrom<NullablesToNormal>(source);
                target.InjectFrom<NormalToNullables>(source);
                target.InjectFrom<IntToEnum>(source);
                target.InjectFrom<EnumToInt>(source);
                target.InjectFrom<MapperInjection>(source);
    
                return target;
            }
        }
    
        public class EnumerableTypeMapper<TSource, TTarget> : ITypeMapper<TSource, TTarget>
            where TSource : class
            where TTarget : class
        {
            public TTarget Map(TSource source, TTarget target)
            {
                if (source == null) return null;
                var targetArgumentType = typeof(TTarget).GetGenericArguments()[0];
    
                var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(targetArgumentType));
                var add = list.GetType().GetMethod("Add");
    
                foreach (var o in source as System.Collections.IEnumerable)
                {
                    var t = Creator.Create(targetArgumentType);
                    add.Invoke(list, new[] { Mapper.Map(o, t, o.GetType(), targetArgumentType) });
                }
                return (TTarget)list;
            }
        }
    
        public static class TypeExtensions
        {
            //returns true if type is IEnumerable<> or ICollection<>, IList<> ...
            public static bool IsEnumerable(this Type type)
            {
                if (type.IsGenericType)
                {
                    if (type.GetGenericTypeDefinition().GetInterfaces().Contains(typeof(System.Collections.IEnumerable)))
                        return true;
                }
                return false;
            }
        }
    
        public static class Creator
        {
            public static object Create(Type type)
            {
                if (type.IsEnumerable())
                {
                    return Activator.CreateInstance(typeof(List<>).MakeGenericType(type.GetGenericArguments()[0]));
                }
    
                if (type.IsInterface)
                    throw new Exception("don't know any implementation of this type: " + type.Name);
    
                return Activator.CreateInstance(type);
            }
        }
    
        public class MapperInjection : ConventionInjection
        {
            public const int MaxDepth = 20;
            public static int _depth = 0;
    
            protected override bool Match(ConventionInfo c)
            {
                return c.SourceProp.Name == c.TargetProp.Name &&
                    !c.SourceProp.Type.IsValueType && c.SourceProp.Type != typeof(string) &&
                    !c.SourceProp.Type.IsGenericType && !c.TargetProp.Type.IsGenericType
                    ||
                     c.SourceProp.Type.IsEnumerable() &&
                       c.TargetProp.Type.IsEnumerable();
            }
    
            protected override object SetValue(ConventionInfo c)
            {
                if (c.SourceProp.Value == null)
                {
                    return null;
                }
                if (_depth > MaxDepth)
                    return Mapper.MapFinal(c.SourceProp.Value, c.TargetProp.Value, c.SourceProp.Type, c.TargetProp.Type);
                _depth++;
                object val = Mapper.Map(c.SourceProp.Value, c.TargetProp.Value, c.SourceProp.Type, c.TargetProp.Type);
                _depth--;
                return val;
            }
        }
    
        public class EnumToInt : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return c.SourceProp.Name == c.TargetProp.Name &&
                    c.SourceProp.Type.IsSubclassOf(typeof(Enum)) && c.TargetProp.Type == typeof(int);
            }
        }
    
        public class IntToEnum : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return c.SourceProp.Name == c.TargetProp.Name &&
                    c.SourceProp.Type == typeof(int) && c.TargetProp.Type.IsSubclassOf(typeof(Enum));
            }
        }
    
        //e.g. int? -> int
        public class NullablesToNormal : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return c.SourceProp.Name == c.TargetProp.Name &&
                       Nullable.GetUnderlyingType(c.SourceProp.Type) == c.TargetProp.Type;
            }
        }
    
        //e.g. int -> int?
        public class NormalToNullables : ConventionInjection
        {
        
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                   c.SourceProp.Type == Nullable.GetUnderlyingType(c.TargetProp.Type);
        }
    }
