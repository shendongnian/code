    public void ReadOutput(Object processState) {
        var process = processState as Process;
        if (process == null) return;
        var output = exeProcess.StandardOutput.ReadToEnd();
        // Do whetever with output
    }
