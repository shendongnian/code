    // In MyForm
    private int counter = 1;
    public void Counter(int count)
    {
        counter = count;
    }
    // Example
    MyForm newForm = new MyForm();
    counter++;
    newForm.Counter(counter);
