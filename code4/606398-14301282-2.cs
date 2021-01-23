    interface Task
    {
        // some common Task interface here...
    }
    class TaskImpl
    // Or: class TaskImpl : Task // depends on your needs
    {    
        // some common Task-related implementation here...
    }
    class CompressTask: Task
    {
        TaskImpl taskImpl; // contains the task-related implementation
        Task task;  // contains the target task(s) to be compressed
        // other code...
    }
    class StandloneTaskType1: Task
    {
        TaskImpl taskImpl;
        // other code...
    }
    .
    .
    .
    
    class StandloneTaskTypeN: Task
    {
        TaskImpl taskImpl;
        // other code...
    }
