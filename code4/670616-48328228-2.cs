    [WorkflowDescription("1.0")]
    public class TranscodeWorkflow : Workflow
    {
      public TranscodeWorkflow()
      {
        //DownloadActivity is the startup activity and will be scheduled when workflow is started.
        ScheduleActivity<DownloadActivity>().OnFailure(Reschedule);
    
    	//After DownloadActivity is completed TranscodeActivity activity will be scheduled.
        ScheduleActivity<TranscodeActivity>().AfterActivity<DownloadActivity>()
            .WithInput(a => new {InputFile = ParentResult(a).DownloadedFile, Format = "MP4"})
        
        ScheduleActivity<UploadToS3Activity>().AfterActivity<TranscodeActivity>()
            .WithInput(a => new {InputFile = ParentResult(a).TranscodedFile});
       
        ScheduleActivity<SendConfirmationActivity>().AfterActivity<UploadToS3Activity>();
      }
      private static dynamic ParentResult(IActivityItem a) => a.ParentActivity().Result();
    }
