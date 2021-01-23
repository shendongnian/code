    private void sort(object toBeSorted)
    {
        if(toBeSorted is Step)
        {
            callStepSort();
        }
        else if(toBeSorted is AutoStep)
        {
            callAutoStepSort();
        }
    }
