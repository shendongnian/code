    //Need a dummy type that is throwable and can hold an Exception
    public sealed class RethrowException : Exception
    {
        public RethrowException(Exception inner) : base(null, inner) { }
    }
    
    public static Functional
    {
        public static void Throw(Exception e)
        {
            if (e is RethrowException)
                throw Exception(
                    "Tried to start a (throw, rethrow, ..., rethrow) " +
                    "chain with a RethrowException.");
            throw e;
        }
    
        public static void Rethrow(Exception e)
        {
            throw new RethrowException(e);
        }
    
        public static void TryCatch(Action _try, Action<Exception> _catch)
        {
            try { _try(); }
            catch (RethrowException e) { _catch(e.InnerException); }
            catch (Exception e) { _catch(e); }
        }
    
        public static T TryCatch<T>(Func<T> _try, Func<Exception, T> _catch)
        {
            try { return _try(); }
            catch (RethrowException e) { return _catch(e.InnerException); }
            catch (Exception e) { return _catch(e); }
        }
    
        public static void TryCatchFinally(
            Action _try, Action<Exception> _catch, Action _finally)
        {
            try { _try(); }
            catch (RethrowException e) { _catch(e.InnerException); }
            catch (Exception e) { _catch(e); }
            finally { _finally(); }
        }
    
        public static T TryCatchFinally<T>(
            Func<T> _try, Func<Exception, T> _catch, Action _finally)
        {
            try { return _try(); }
            catch (RethrowException e) { return _catch(e.InnerException); }
            catch (Exception e) { return _catch(e); }
            finally { _finally(); }
        }
    }
