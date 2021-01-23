    public void MakePath(ref List<string> routes)
    {
        bool is_start;
        for (int i = 0; i < routes.Count - 1; i++)
        {
            is_start = true;
            for (int j = 0; j < routes.Count; j++)
            {
                 if (routes[i][0] == routes[j][1]){
                    is_start = false;
                    break;
                  }
            }
            if (is_start) {
                 var temp = routes[i];
                 routes[i] = routes[0];
                 routes[0] = temp;
            }
         }           
        for (int i = 0; i < routes.Count - 1; i++)
        {
            for (int j = 0; j < routes.Count; j++)
            {
                if (routes[i][1] == routes[j][0])
                {
                    var temp = routes[i + 1];
                    routes[i + 1] = routes[j];
                    routes[j] = temp;
                    j = routes.Count;
                }
            }
        }
    }
