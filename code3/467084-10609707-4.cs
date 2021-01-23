    namespace ReflectionConsole {
        class Program {
            static void Main(string[] args)
            {
    
                object test = TryToReflectBuilder("ReflectionConsole.Test");
                Console.ReadKey();
            }
    
            public static object TryToReflectBuilder(string type)
            {
                //getting the assembly : not same as your way, but... that wasn't a problem for you
                var assembly = Assembly.GetAssembly(typeof(Test));
    
                //getting the entityType by name.
                var entityType = assembly.GetType(type);
                //The interesting (I hope) part is starting (yeah)
                //get the Builder<T> type
                var builderClassType = typeof(Builder<>);
                //create generic argument for Builder<T> will take the type of our entity (always an array)
                Type[] args = {entityType};
    
                //pass generic arguments to Builder<T>. Which becomes Builder<entityType>
                var genericBuilderType = builderClassType.MakeGenericType(args);
                //create a new instance of Builder<entityType>
                var builder = Activator.CreateInstance(genericBuilderType);
                //retrieve the "CreateNew" method, which belongs to Builder<T> class
                var createNewMethodInfo = builder.GetType().GetMethod("CreateNew");
                //invoke "CreateNew" from our builder instance which gives us an ObjectBuilder<T>, so now an ObjectBuilder<entityType> (well as an ISingleObjectBuilder<entityType>, but... who minds ;))
                var objectBuilder = createNewMethodInfo.Invoke(builder, null);
                //retrieve the "Build" method, which belongs to ObjectBuilder<T> class
                var buildMethodInfo = objectBuilder.GetType().GetMethod("Build");
                //finally, invoke "Build" from our ObjectBuilder<entityType> instance, which will give us... our entity !
                var result = buildMethodInfo.Invoke(objectBuilder, null);
                //it would be sad to return nothing after all these efforts, no ??
                return result;
            }
        }
    
        public  class Builder<T>
        {
            public static ISingleObjectBuilder<T> CreateNew()
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
