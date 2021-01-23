    public class AwesomeDAL
        public virtual void AddCompany(string name, string motto){
            using (var docStore = new DocumentStore("localhost", 8080).Initialize())
            using (var session = documentStore.OpenSession()){
                session.Store(new Company { Name = name, Motto = motto });;
                session.SaveChanges();
            }
    }
