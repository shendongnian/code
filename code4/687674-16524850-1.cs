    public ref class PDWrapperClass
    {
        // TODO: Add your methods for this class here.
    public :
        PDWrapperClass();
        ~PDWrapperClass();
    private:
        CPrivacyDetectEngine* m_pCPrivacyDetectEngine;
    public:
        void initEngine() { m_pCPrivacyDetectEngine->initEngine(); }
    };
