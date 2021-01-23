    public ref class ClassWithIndexer
    {
    private:
    	array<int> ^x;
    public:
    	property int default[int]
    	{
    		int get(int index)
    		{
    			return x[index];
    		}
    		void set(int index, int value)
    		{
    			x[index] = value;
    		}
    	}
    };
