    bool haveSkeletonData = false;
    using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
    {
    if (skeletonFrame != null)
    {
        if ((this.skeletonData == null) || (this.skeletonData.Length != skeletonFrame.SkeletonArrayLength))
        {
            this.skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];
        }
        skeletonFrame.CopySkeletonDataTo(skeletonData);
        haveSkeletonData = true;
    }
    else
    {
        haveSkeletonData = false;
    }
    }
    if (haveSkeletonData)
    {
       // here i can put code that is using my timestamp 
    }
