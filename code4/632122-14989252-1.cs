    void UpdateGeneration()
    {
        mAdapter.next();
        mLifeGrid.setAdapter(mAdapter);
        mHandler.PostDelayed(UpdateGeneration, 1000);
    }
    // ...
    mHandler.PostDelayed(UpdateGeneration, 1000);
