    namespace ReflectionConsole {
        class Program {
            static void Main(string[] args)
            {
    
                object test = TryToReflectBuilder("ReflectionConsole.Test");
            }
    
            public static object TryToReflectBuilder(string type)
            {
                var assembly = Assembly.GetAssembly(typeof(Test));
                var entityType = assembly.GetType(type);
                var builderClassType = typeof(Builder<>);
                Type[] args = {entityType};
                var genericBuilderType = builderClassType.MakeGenericType(args);
                var builder = Activator.CreateInstance(genericBuilderType);
    
                var createNewMethodInfo = builder.GetType().GetMethod("CreateNew");
                var objectBuilder = createNewMethodInfo.Invoke(builder, null);
    
                var buildMethodInfo = objectBuilder.GetType().GetMethod("Build");
    
                var result = buildMethodInfo.Invoke(objectBuilder, null);
                return result;
            }
        }
    
        public  class Builder<T>
        {
            public ISingleObjectBuilder<T> CreateNew()
            {
                Console.WriteLine(string.Format("{0} creating new",typeof(T)));
                return new ObjectBuilder<T>();
            } 
        }
    
        public interface ISingleObjectBuilder<T> : IBuildable<T>
        {
        }
        public interface IObjectBuilder<T> : ISingleObjectBuilder<T>
        {
            
        }
        public interface IBuildable<T>
        {
            T Build();
        }
    
        public class ObjectBuilder<T> : ISingleObjectBuilder<T>
        {
            public T Build()
            {
                Console.WriteLine(string.Format("{0} building myself", typeof(T)));
                return Activator.CreateInstance<T>();
            }
        }
    
        public class Test
        {
        }
    }
