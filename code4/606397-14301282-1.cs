    interface Task
    {
        // some common Task interface here...
    }
    class TaskImpl
    {    
        // some common Task-related implementation here...
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
    class CompressTask: Task
    {
        TaskImpl taskImpl; // contains the task-related implementation
        Task task;  // contains the task to be compress
        // other code...
    }
