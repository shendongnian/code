    public Action UpdateProgress;  // In place of event handler declaration
                                   // declare an Action delegate
    .
    .
    .
    private LoadData() {
        this.UpdateProgress();    // call to Action delegate - MyMethod in
                                  // parent
    }
