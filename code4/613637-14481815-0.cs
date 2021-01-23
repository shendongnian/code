    class EventData
    {
    };
    // base class for all the secondary classes which expect to get a call back control from
    // the first object where we perform hit-test.
    class EventHandler
    {
    public:
    virtual void performAction(EventData* ed) = 0;
    };
    // Second class constructor can register itself to your first object.
    class SecondClass : public EventHandler
    {
    public:
        SecondClass()
        { 
            ImageButton::registerForEventAction(*this);
        }
        void performAction(EventData* ed)
        {
           // this method gets called back when a hit test gets passed and we will get control
           // at the same time at second object to perform necessary operation.
        }
    };
    // ... extending your first class with below method, and another member variable.
    class ImageButton 
    {
    // extension to base definition of ImageButton .. assuming namespace kind of convention 
    // just for simplicity and completeness
    private:
    std::vector<EventHandler&> registeredHandlers;
    public:
    static void ImageButton::registerForEventAction(EventHandler& eh)
    {
      // For Simplicity I'm assuming your First class object is singleton, if not you need to
      // figure out how you can get access to first object in your second class.
 
     ImageButton::getInstance().registeredHandlers.push_back(eh);
    }
    bool hitTest(int, int)
    {
    bool success = true; 
    // ideally above variable should be set to false at the start setting it to true for 
    // readability
       if (success) {
            for (std::vector<EventHandler&>::iterator i = registeredHandlers.begin(); i !=       registeredHandlers.end(); ++i) {
            // pass on any event data if you need to.
               (*i).performAction(NULL);
            }
        } // End of if
    }// End of method
    }; // End of Class Definition
