    using System.Collections;
    
    Queue passwords = new Queue();
    
    foreach (int p in new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })
    {
       passwords.Enqueue(p);
    }
    
    //just to show you that it's FIFO (first-in, first-out)
    while (passwords.Count > 0)
    {
       MessageBox.Show("Your password is " + passwords.Dequeue();
    }   
