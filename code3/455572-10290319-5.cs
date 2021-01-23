    public Student getStudent(int age, string name)
    {
        return this.getData().Find(s => Convert.ToInt32(s.Age) == age && s.Name.Equals(name));
    }
    public Student getByIndex(int index)
    {
        Student s = null;
        // maxIndex will be: 7
        // your array goes from 0 to 7
        int maxIndex = this.getData().Count() - 1;
        // If your index does not exceed the elements of the array:
        if (index <= maxIndex)
            s  = this.getData()[index];
        return s;
    }
