        public interface IMyInterface
        {
            int raw { get; set;  }
        }
        public static T GetStruct<T>(UInt32 sector) where T: struct , IMyInterface
        {
            var obj = new T();
            obj.raw = 0;
            return obj;
        }
