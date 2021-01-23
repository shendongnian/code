    public static class ContextProvider {
        public static ObjectContext CurrentContext {
            get { return HttpContext.Items["CurrentObjectContext"];
        }
        public static void OpenNew(){
            var context = new ObjectContext();
            HttpContext.Items["CurrentObjectContext"] = context; 
        }
        public static void CloseCurrent(){
            var context = CurrentContext;
            HttpContext.Items["CurrentObjectContext"] = null;
            // Do whatever tracking you want to do with the object context. For instance:
            // if( error == false) { 
            //     context.DetectChanges();
            //     context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            // }
            context.Dispose();
        }
    }
