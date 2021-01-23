    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    public class UnityBlockRegistrationExtender : UnityContainerExtension
    {
        private readonly NameToTypesMap nameToTypesMap = new NameToTypesMap();
        protected override void Initialize()
        {
            var blockType = typeof(IBlock);
            var blockTypes = Assembly.GetEntryAssembly().GetTypes()
                .Where(block => blockType.IsAssignableFrom(block) && block.IsClass);
            foreach (var type in blockTypes)
            {
                if (this.nameToTypesMap.AddType(type.AssemblyQualifiedName, type))
                {
                    var block = this.Container.Resolve(type) as IBlock;
                    block.Register(this.Container);
                }
            }
        }
        private class NameToTypesMap
        {
            private readonly Dictionary<string, Type> map = new Dictionary<string, Type>();
            internal bool AddType(string name, Type type)
            {
                if (name == null)
                {
                    throw new ArgumentNullException("name", "A name is required.");
                }
                if (type == null)
                {
                    throw new ArgumentNullException("type", "A Type object is required.");
                }
                lock (this.map)
                {
                    if (!this.map.ContainsKey(name))
                    {
                        this.map[name] = type;
                        return true;
                    }
                }
                return false;
            }
        }
    }
