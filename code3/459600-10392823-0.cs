public event Action<string> MyEvent = delegate { };
                if (SkeletonID1 == SkeletonID2)
                {
                    this.MyEvent("Your IDs are Matching!");
                }
                else if (SkeletonID2 != SkeletonID1)
                {
                    this.MyEvent("Your IDs don't Match.");
                }
     if (PersonDetected == true)
                {
                    this.MyEvent("Scan Aborted");
                }
