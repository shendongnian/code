    void thread1()
    {
        lock(serialPort1)
        { 
             serialPort1.Write(something);
        }
    }
    void thread2()
    {
        lock(serialPort1)
        { 
             serialPort1.Write(somethingelse);
        }
    }
