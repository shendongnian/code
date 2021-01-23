    public T currentRow
    {
        get
        {
            int position = this.BindingContext[bindingSource1].Position;
            if (position > -1)
            {
                return (T)bindingSource1.Current;
            }
            else
            {
                return null;
            }
        }
    }
