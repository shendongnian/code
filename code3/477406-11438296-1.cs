    public ref class Vector4 
    {   
      private:
        Vector4_CPP test;
    
        Vector4(Vector4_CPP* value)
        {
            this->test = *value;
        }
    
      public:
        Vector4(Vector4^ value)
        {
            test = value->test;
        }
    
        Vector4(System::Single x, System::Single y, System::Single z, System::Single w)
        {
            test = Vector4_CPP( x, y, z, w ) ;
        } 
    }
