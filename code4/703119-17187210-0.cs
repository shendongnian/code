        public void CalculateObjsInView()
        {
            foreach (Obj o in new List<Obj>(ObjInstanceList))
            {
                if (o == null)
                    continue;
                if (Camera.CollisionMask.Intersects(o.CollisionMask))
                    o.IsInView = true;
                else
                    o.IsInView = false;
            }
        }
