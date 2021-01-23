    namespace System.Threading.Tasks
    {
        abstract class Task { }
        abstract class Task<TResult> : Task { }
    }
    
    namespace System.Runtime.CompilerServices
    {
        interface INotifyCompletion { }
        interface ICriticalNotifyCompletion { }
        
        interface IAsyncStateMachine
        {
            void MoveNext();
            void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    
        struct AsyncVoidMethodBuilder
        {
            public static AsyncVoidMethodBuilder Create() { … }
            public void Start<TStateMachine>(ref TStateMachine stateMachine)
                // where TStateMachine : IAsyncStateMachine
                { … }
            public void SetResult() { … }
            public void SetException(Exception exception) { … }
            public void SetStateMachine(IAsyncStateMachine stateMachine) { … }
            public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                // where TAwaiter : INotifyCompletion
                // where TStateMachine : IAsyncStateMachine
                { … }
            public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                // where TAwaiter : ICriticalNotifyCompletion
                // where TStateMachine : IAsyncStateMachine
                { … }
        }
    
        struct AsyncTaskMethodBuilder
        {
            public Task Task { get { … } }
            public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                // where TAwaiter : INotifyCompletion
                // where TStateMachine : IAsyncStateMachine
                { … }
            public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                // where TAwaiter : ICriticalNotifyCompletion
                // where TStateMachine : IAsyncStateMachine
                { … }
            public static AsyncTaskMethodBuilder Create() { … }
            public void SetException(Exception exception) { … }
            public void SetResult() { … }
            public void SetStateMachine(IAsyncStateMachine stateMachine) { … }
            public void Start<TStateMachine>(ref TStateMachine stateMachine) 
                // where TStateMachine : IAsyncStateMachine
                { … }
        }
    
        struct AsyncTaskMethodBuilder<TResult>
        {
            public static AsyncTaskMethodBuilder<TResult> Create() { … }
            public void Start<TStateMachine>(ref TStateMachine stateMachine) 
                // where TStateMachine : IAsyncStateMachine 
                { … }
            public void SetResult(TResult result) { … }
            public void SetException(Exception exception) { … }
            public void SetStateMachine(IAsyncStateMachine stateMachine) { … }
            public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                // where TAwaiter : INotifyCompletion
                // where TStateMachine : IAsyncStateMachine 
                { … }
            public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                // where TAwaiter : ICriticalNotifyCompletion
                // where TStateMachine : IAsyncStateMachine 
                { … }
            public Task<TResult> Task { get { … } }
        }
    }
