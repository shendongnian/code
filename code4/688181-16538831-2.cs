    catch(Exception ex) {
        while(ex != null) {
            Trace.WriteLine(ex.Message);
            ex = ex.InnerException;
        }
    }
