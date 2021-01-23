    public ref class StudentWrapper
    {
    private:
      Student *_stu;
    public:
      StudentWrapper(String ^fullname, double gpa)
      {
        _stu = new Student((char *) 
               System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(
               fullname).ToPointer(), 
          gpa);
      }
      ~StudentWrapper()
      {
        delete _stu;
        _stu = 0;
      }
    
      property String ^Name
      {
        String ^get()
        {
          return gcnew String(_stu->getName());
        }
      }
      property double Gpa
      {
        double get()
        {
          return _stu->getGpa();
        }
      }
    };
