    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public static class TypeEx
    {
        /// <summary>
        /// Type, Tuple&lt;Methods of type, (for interfaces)methods of base interfaces shadowed&gt;
        /// </summary>
        public static readonly ConcurrentDictionary<Type, Tuple<MethodInfo[], HashSet<MethodInfo>>> Methods = new ConcurrentDictionary<Type, Tuple<MethodInfo[], HashSet<MethodInfo>>>();
        /// <summary>
        /// Type, Tuple&lt;Properties of type, (for interfaces)properties of base interfaces shadowed&gt;
        /// </summary>
        public static readonly ConcurrentDictionary<Type, Tuple<PropertyInfo[], HashSet<PropertyInfo>>> Properties = new ConcurrentDictionary<Type, Tuple<PropertyInfo[], HashSet<PropertyInfo>>>();
        public static MethodInfo[] GetVisibleMethods(this Type type)
        {
            if (type.IsInterface)
            {
                return (MethodInfo[])type.GetVisibleMethodsInterfaceImpl().Item1.Clone();
            }
            return (MethodInfo[])type.GetVisibleMethodsImpl().Clone();
        }
        public static PropertyInfo[] GetVisibleProperties(this Type type)
        {
            if (type.IsInterface)
            {
                return (PropertyInfo[])type.GetVisiblePropertiesInterfaceImpl().Item1.Clone();
            }
            return (PropertyInfo[])type.GetVisiblePropertiesImpl().Clone();
        }
        private static MethodInfo[] GetVisibleMethodsImpl(this Type type)
        {
            Tuple<MethodInfo[], HashSet<MethodInfo>> tuple;
            if (Methods.TryGetValue(type, out tuple))
            {
                return tuple.Item1;
            }
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            if (type.BaseType == null)
            {
                Methods.TryAdd(type, Tuple.Create(methods, (HashSet<MethodInfo>)null));
                return methods;
            }
            var baseMethods = type.BaseType.GetVisibleMethodsImpl().ToList();
            foreach (var method in methods)
            {
                if (method.IsHideByName())
                {
                    baseMethods.RemoveAll(p => p.Name == method.Name);
                }
                else
                {
                    int numGenericArguments = method.GetGenericArguments().Length;
                    var parameters = method.GetParameters();
                    baseMethods.RemoveAll(p =>
                    {
                        if (!method.EqualSignature(numGenericArguments, parameters, p))
                        {
                            return false;
                        }
                        return true;
                    });
                }
            }
            if (baseMethods.Count == 0)
            {
                Methods.TryAdd(type, Tuple.Create(methods, (HashSet<MethodInfo>)null));
                return methods;
            }
            var methods3 = new MethodInfo[methods.Length + baseMethods.Count];
            Array.Copy(methods, 0, methods3, 0, methods.Length);
            baseMethods.CopyTo(methods3, methods.Length);
            Methods.TryAdd(type, Tuple.Create(methods3, (HashSet<MethodInfo>)null));
            return methods3;
        }
        private static Tuple<MethodInfo[], HashSet<MethodInfo>> GetVisibleMethodsInterfaceImpl(this Type type)
        {
            Tuple<MethodInfo[], HashSet<MethodInfo>> tuple;
            if (Methods.TryGetValue(type, out tuple))
            {
                return tuple;
            }
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var baseInterfaces = type.GetInterfaces();
            if (baseInterfaces.Length == 0)
            {
                tuple = Tuple.Create(methods, new HashSet<MethodInfo>());
                Methods.TryAdd(type, tuple);
                return tuple;
            }
            var baseMethods = new List<MethodInfo>();
            var baseMethodsTemp = new MethodInfo[baseInterfaces.Length][];
            var shadowedMethods = new HashSet<MethodInfo>();
            for (int i = 0; i < baseInterfaces.Length; i++)
            {
                var tuple2 = baseInterfaces[i].GetVisibleMethodsInterfaceImpl();
                baseMethodsTemp[i] = tuple2.Item1;
                shadowedMethods.UnionWith(tuple2.Item2);
            }
            for (int i = 0; i < baseInterfaces.Length; i++)
            {
                baseMethods.AddRange(baseMethodsTemp[i].Where(p => !shadowedMethods.Contains(p)));
            }
            foreach (var method in methods)
            {
                if (method.IsHideByName())
                {
                    baseMethods.RemoveAll(p =>
                    {
                        if (p.Name == method.Name)
                        {
                            shadowedMethods.Add(p);
                            return true;
                        }
                        return false;
                    });
                }
                else
                {
                    int numGenericArguments = method.GetGenericArguments().Length;
                    var parameters = method.GetParameters();
                    baseMethods.RemoveAll(p =>
                    {
                        if (!method.EqualSignature(numGenericArguments, parameters, p))
                        {
                            return false;
                        }
                        shadowedMethods.Add(p);
                        return true;
                    });
                }
            }
            if (baseMethods.Count == 0)
            {
                tuple = Tuple.Create(methods, shadowedMethods);
                Methods.TryAdd(type, tuple);
                return tuple;
            }
            var methods3 = new MethodInfo[methods.Length + baseMethods.Count];
            Array.Copy(methods, 0, methods3, 0, methods.Length);
            baseMethods.CopyTo(methods3, methods.Length);
            tuple = Tuple.Create(methods3, shadowedMethods);
            Methods.TryAdd(type, tuple);
            return tuple;
        }
        private static PropertyInfo[] GetVisiblePropertiesImpl(this Type type)
        {
            Tuple<PropertyInfo[], HashSet<PropertyInfo>> tuple;
            if (Properties.TryGetValue(type, out tuple))
            {
                return tuple.Item1;
            }
            var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static);
            if (type.BaseType == null)
            {
                Properties.TryAdd(type, Tuple.Create(properties, (HashSet<PropertyInfo>)null));
                return properties;
            }
            var baseProperties = type.BaseType.GetVisiblePropertiesImpl().ToList();
            foreach (var property in properties)
            {
                if (property.IsHideByName())
                {
                    baseProperties.RemoveAll(p => p.Name == property.Name);
                }
                else
                {
                    var indexers = property.GetIndexParameters();
                    baseProperties.RemoveAll(p =>
                    {
                        if (!property.EqualSignature(indexers, p))
                        {
                            return false;
                        }
                        return true;
                    });
                }
            }
            if (baseProperties.Count == 0)
            {
                Properties.TryAdd(type, Tuple.Create(properties, (HashSet<PropertyInfo>)null));
                return properties;
            }
            var properties3 = new PropertyInfo[properties.Length + baseProperties.Count];
            Array.Copy(properties, 0, properties3, 0, properties.Length);
            baseProperties.CopyTo(properties3, properties.Length);
            Properties.TryAdd(type, Tuple.Create(properties3, (HashSet<PropertyInfo>)null));
            return properties3;
        }
        private static Tuple<PropertyInfo[], HashSet<PropertyInfo>> GetVisiblePropertiesInterfaceImpl(this Type type)
        {
            Tuple<PropertyInfo[], HashSet<PropertyInfo>> tuple;
            if (Properties.TryGetValue(type, out tuple))
            {
                return tuple;
            }
            var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var baseInterfaces = type.GetInterfaces();
            if (baseInterfaces.Length == 0)
            {
                tuple = Tuple.Create(properties, new HashSet<PropertyInfo>());
                Properties.TryAdd(type, tuple);
                return tuple;
            }
            var baseProperties = new List<PropertyInfo>();
            var basePropertiesTemp = new PropertyInfo[baseInterfaces.Length][];
            var shadowedProperties = new HashSet<PropertyInfo>();
            for (int i = 0; i < baseInterfaces.Length; i++)
            {
                var tuple2 = baseInterfaces[i].GetVisiblePropertiesInterfaceImpl();
                basePropertiesTemp[i] = tuple2.Item1;
                shadowedProperties.UnionWith(tuple2.Item2);
            }
            for (int i = 0; i < baseInterfaces.Length; i++)
            {
                baseProperties.AddRange(basePropertiesTemp[i].Where(p => !shadowedProperties.Contains(p)));
            }
            foreach (var property in properties)
            {
                if (property.IsHideByName())
                {
                    baseProperties.RemoveAll(p =>
                    {
                        if (p.Name == property.Name)
                        {
                            shadowedProperties.Add(p);
                            return true;
                        }
                        return false;
                    });
                }
                else
                {
                    var indexers = property.GetIndexParameters();
                    baseProperties.RemoveAll(p =>
                    {
                        if (!property.EqualSignature(indexers, p))
                        {
                            return false;
                        }
                        shadowedProperties.Add(p);
                        return true;
                    });
                }
            }
            if (baseProperties.Count == 0)
            {
                tuple = Tuple.Create(properties, shadowedProperties);
                Properties.TryAdd(type, tuple);
                return tuple;
            }
            var properties3 = new PropertyInfo[properties.Length + baseProperties.Count];
            Array.Copy(properties, 0, properties3, 0, properties.Length);
            baseProperties.CopyTo(properties3, properties.Length);
            tuple = Tuple.Create(properties3, shadowedProperties);
            Properties.TryAdd(type, tuple);
            return tuple;
        }
        private static bool EqualSignature(this MethodInfo method1, int numGenericArguments1, ParameterInfo[] parameters1, MethodInfo method2)
        {
            // To shadow by signature a method must have same name, same number of 
            // generic arguments, same number of parameters and same parameters' type
            if (method1.Name != method2.Name)
            {
                return false;
            }
            if (numGenericArguments1 != method2.GetGenericArguments().Length)
            {
                return false;
            }
            var parameters2 = method2.GetParameters();
            if (!parameters1.EqualParameterTypes(parameters2))
            {
                return false;
            }
            return true;
        }
        private static bool EqualSignature(this PropertyInfo property1, ParameterInfo[] indexers1, PropertyInfo property2)
        {
            // To shadow by signature a property must have same name, 
            // same number of indexers and same indexers' type
            if (property1.Name != property2.Name)
            {
                return false;
            }
            var parameters2 = property1.GetIndexParameters();
            if (!indexers1.EqualParameterTypes(parameters2))
            {
                return false;
            }
            return true;
        }
        private static bool EqualParameterTypes(this ParameterInfo[] parameters1, ParameterInfo[] parameters2)
        {
            if (parameters1.Length != parameters2.Length)
            {
                return false;
            }
            for (int i = 0; i < parameters1.Length; i++)
            {
                if (parameters1[i].IsOut != parameters2[i].IsOut)
                {
                    return false;
                }
                if (parameters1[i].ParameterType.IsGenericParameter)
                {
                    if (!parameters2[i].ParameterType.IsGenericParameter)
                    {
                        return false;
                    }
                    if (parameters1[i].ParameterType.GenericParameterPosition != parameters2[i].ParameterType.GenericParameterPosition)
                    {
                        return false;
                    }
                }
                else if (parameters1[i].ParameterType != parameters2[i].ParameterType)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsHideByName(this MethodInfo method)
        {
            if (!method.Attributes.HasFlag(MethodAttributes.HideBySig) && (!method.Attributes.HasFlag(MethodAttributes.Virtual) || method.Attributes.HasFlag(MethodAttributes.NewSlot)))
            {
                return true;
            }
            return false;
        }
        private static bool IsHideByName(this PropertyInfo property)
        {
            var get = property.GetGetMethod();
            if (get != null && get.IsHideByName())
            {
                return true;
            }
            var set = property.GetSetMethod();
            if (set != null && set.IsHideByName())
            {
                return true;
            }
            return false;
        }
    }
