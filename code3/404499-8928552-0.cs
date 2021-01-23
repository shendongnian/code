            foreach (var type in Assembly.GetAssembly(this.GetType()).GetTypes())
            {
                if (type.BaseType == this.GetType())
                    yield return type;
            }
