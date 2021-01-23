    public class UserModel : BaseModel {
        protected override string GetDataToSaveInDB() {
            return "Field1=" + Field1 + ";Field2=" + Field2;
        }
    }
