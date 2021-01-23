     static void GetGenericParametersNames(Type type)
            {
                Queue<Type> typeQueue = new Queue<Type>();
                typeQueue.Enqueue(type);
                while (typeQueue.Any())
                {
                    var t = typeQueue.Dequeue();
                    Console.WriteLine("  {0}", arg);
    
                    foreach (Type arg in t.GetGenericArguments())
                    {
                        typeQueue.Enqueue(t);
                    }
                }
            }
