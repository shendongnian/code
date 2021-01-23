    public class MyPluginStep
    {
        ITaskRepository taskRepository;
        public MyPluginStep(ITaskRepository repo)
        {
            taskRepository = repo;
        }
        public MyPluginStep()
        {
            taskRepository = new DefaultTaskRepositoryImplementation();
        }
        public MyExecuteMethod(mypluginstepparams){
            Task task = taskRepository.GetTaskByContact(...);
        }
