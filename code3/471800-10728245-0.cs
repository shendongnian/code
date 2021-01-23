    MethodInvoker mi = new MethodInvoker(() => progressBar.Progress = newProgressValue);
    if (progressBar.InvokeRequired)
    {
        progressBar.Invoke(mi);
    }
    else
    {
        mi.Invoke();
    }
