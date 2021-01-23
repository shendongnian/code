    public void MakePath(ref List<string> routes)
    {
        bool is_first, is_last;
        for (int i = 0; i < routes.Count - 1; i++)
        {
            is_first = true;
            is_last = true;
            for (int j = 0; j < routes.Count; j++)
            {
                 if (routes[i][1] == routes[j][0]){
                    is_last = false;
                    break;
                 }
                 if (routes[i][0] == routes[j][1]){
                    is_start = false;
                    break;
                 }
            }
            if (is_first) {
                 var temp = routes[i];
                 routes[i] = routes[0];
                 routes[0] = temp;
            }
            if (is_last) {
                 var temp = routes[i];
                 routes[i] = routes[routes.Count];
                 routes[routes.Count] = temp;
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
