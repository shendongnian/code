         MyFileDir root = new MyFileDir(); //root Node
&
         var curNode = myLinkedList.First;
        while (IsRunning)
        {
            if (curNode.Next == null) // wait until next node is not null
            {
                Thread.Sleep(100);
                continue;
            }
            curNode = curNode.Next;
            curFileDir = new MyFileDir(curNode);// your cast here
        
        List<string> mylist = curFileDir.FullPath.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries).ToList(); // this gives a list of dirs in FullPath to explore
      
            
            MyFileDir temp = root;
            foreach (string filedirName in mylist)
            {
                temp = AddNode(temp, filedirName );
            }
        
      }
