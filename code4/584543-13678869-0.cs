    foo.Enabled = false;
    bar.Enabled = false;
    // etc
    await Task.Run(...);
    foo.Enabled = true;
    bar.Enabled = true;
