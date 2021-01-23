    public void Push(int value)
    {
        if (top == (StackSize - 1))
        {
            Console.WriteLine("Stack is full!");
        }
        else
        {          
            item[++top] = value;
            if(top == 0)
                minima[top] = value;
            else
                minima[top] = Math.Min(value, minima[top - 1]);
            Console.WriteLine("Item pushed successfully!");
            Console.WriteLine(item[top]);
        }
    }
