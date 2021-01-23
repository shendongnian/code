         List<string> tags = new List<string>();
         foreach (object item in lvFiles.Items)
         {
            tags.Add(item.tag.ToString());
         }
         ThreadPool.QueueUserWorkItem(delegate
         {
           for (int i = 0; i < tags.Count && shouldContinue; i++)
           {
               sendQueue(tags[i], adapter);
           }
            //...
         }
