    class ADrawer : Drawer<List<Agent>>
    {
        public override void Draw(List<Agent> list)
        {
            foreach (var a in list)
            {
                DrawA(a);
            }
        }       
      
        public void DrawA(Agent a)
        {
            //draw code here
        }
    }
