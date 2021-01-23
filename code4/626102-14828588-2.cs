    public static class TaskFactory
    {
       public static ITask CreateTask(TaskType taskType)
       {
          switch (taskType)
            cast TaskType.TaskA:
              return new TaskA();
            cast TaskType.TaskB:
              return new TaskB();
            default:
              throw new InvalidArgumentException("unknown task type");
       }
    }
