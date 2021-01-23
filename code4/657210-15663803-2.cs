    public FenetreProgressBar(ObservableCollection<Evenement.FichierJoint> 
                          CollectionFicJointsToAdd)
    {
        InitializeComponent();
        MaProgressBar.Minimum = 0;
        MaProgressBar.Maximum = 100;
        worker.WorkerReportsProgress = true;
        worker.DoWork += worker_DoWork;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.ProgressChanged +=worker_ProgressChanged;
        worker.RunWorkerAsync(CollectionFicJointsToAdd);
    }
