    System.AggregateException: A Task's exception(s) were not observed either by Waiting on the Task or accessing its Exception property. As a result, the unobserved exception was rethrown by the finalizer thread. ---> System.NullReferenceException: Object reference not set to an instance of an object.
       at System.Web.ThreadContext.AssociateWithCurrentThread(Boolean setImpersonationContext)
       at System.Web.HttpApplication.OnThreadEnterPrivate(Boolean setImpersonationContext)
       at System.Web.HttpApplication.System.Web.Util.ISyncContext.Enter()
       at System.Web.Util.SynchronizationHelper.SafeWrapCallback(Action action)
       at System.Threading.Tasks.Task.Execute()
       --- End of inner exception stack trace ---
    ---> (Inner Exception #0) System.NullReferenceException: Object reference not set to an instance of an object.
       at System.Web.ThreadContext.AssociateWithCurrentThread(Boolean setImpersonationContext)
       at System.Web.HttpApplication.OnThreadEnterPrivate(Boolean setImpersonationContext)
       at System.Web.HttpApplication.System.Web.Util.ISyncContext.Enter()
       at System.Web.Util.SynchronizationHelper.SafeWrapCallback(Action action)
       at System.Threading.Tasks.Task.Execute()<---
