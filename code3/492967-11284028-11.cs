    class Controller
    {
        Form1 f1;
        Form2 f2;
        void StartFirstForm()
        {
            f1 = new Form1();
            f1.ProcessingActivated += OnProcessingActivated;
            f1.Show();
        }
        void OnProcessingActivated(object sender, ProcessingActivatedEventArgs args)
        {
            int data = args.MoreData;
            f1.DisableProcessingRequests();
            model.ProcessingFinished += OnProcessingFinished;
            model.StartProcessing(data);
            if (data > 0)
                f2.DisplayDataProcessing(0, data);
            else if (data < 0)
                f2.DisplayDataProcessing(data, 0);
            else
                throw new SomeCoolException("impossible data");
        }
    }
