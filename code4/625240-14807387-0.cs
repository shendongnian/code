    class CircuitBoard :Canvas
    {
        public void Move(string iBoardId, string iCircuitShapeId, double iXCordinate, double iYCordinate)
        {
            string vId = PCBFactory.GetUniqueTag(iCircuitShapeId, vBoard);
            CircuitShape vShape = this.GetComponent(vId);
            if (vShape != null)
            {
               // do something...
            }
          }
        }
    }
