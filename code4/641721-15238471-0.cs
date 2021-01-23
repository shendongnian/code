    int pin7val = 0;     // variable to store the read value
    
    void setup()
    {
      Serial.begin(9600);
      pinMode(7, INPUT);      // sets the digital pin 7 as input
    }
    
    void loop()
    {  
      pin7val = digitalRead(7);   // read the input pin 7
      Serial.write(pin7val + " Pin44");
    }
