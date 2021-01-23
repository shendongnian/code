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
        TaskImpl task;
        // other code...
    }
    .
    .
    .
    
    class StandloneTaskTypeN: Task
    {
        TaskImpl task;
        // other code...
    }
    class CompressTask: Task
    {
        TaskImpl task;
        // other code...
    }
