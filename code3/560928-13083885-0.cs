    interface IDal {
        T Get&lt;T&gt;(id);
        void Save(object o); //or T, if needed
        IQueryable&lt;T&gt; Query&lt;T&gt;();
    }
