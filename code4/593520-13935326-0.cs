    public class BaseModel {
        protected virtual string GetDataToSaveInDB() {
            // if it makes sense to have the data as a string...
        }
        public void Save() {
            string data = GetDataToSaveInDB();
            // do something with data...
        }
    }
