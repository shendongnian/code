     private void ZedGraph_MouseLeave(object sender, EventArgs e)
            {
                if (CrossHairX != null && CrossHairY != null)
                {
                    ZedGraph.GraphPane.GraphObjList.Remove(xHairOld);
                    ZedGraph.GraphPane.GraphObjList.Remove(yHairOld);
                    ZedGraph.Refresh();
                }
            }
