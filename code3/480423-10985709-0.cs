    public ref class Class1 sealed
    {
    public:
        Class1();
        //readonly array
		void TestArray(const Platform::Array<uint8>^ intArray)
		{
		}
        //writeonly array
		void TestOutArray(Platform::WriteOnlyArray<uint8>^ intOutArray)
		{
		}
    };
