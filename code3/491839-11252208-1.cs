    private Tool _tool;
    public MyForm () // Constructor of your form
    {
        _tool = new Tool();
        _tool.ProgressChanged += Tool_ProgressChanged;
    }
    private void Tool_ProgressChanged(int progress)
    {
        progressBar.Progress = progress;
    }
