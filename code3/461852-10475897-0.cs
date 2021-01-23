    Skeleton skeletons = new Skeleton();
                
                skeletons = (from s in allSkeletons
                             where s.TrackingState == SkeletonTrackingState.Tracked ||
                             s.TrackingState == SkeletonTrackingState.PositionOnly
                             select s).FirstOrDefault();
                if (skeletons == null)
                {
                    return;
                }
                if ((skeletons.TrackingState == SkeletonTrackingState.Tracked ||
                    skeletons.TrackingState == SkeletonTrackingState.PositionOnly))
                {
                    PersonDetected = true;
                }
