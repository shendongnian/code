          class Lesson
          {
              public string topic = "math";
              public string teacher = "mandelbrot";
              public string room = "E215";
              public string begin = "08:00";
              public string end = "09:00";
      
              public Lesson()
                  : this(null, null, null, null, null)
              {
              }
      
              public Lesson(string t)
                  : this(t, null, null, null, null)
              {
              }
      
      
              public Lesson(string t, string t2)
                  : this(t, t2, null, null, null)
              {
              }
      
      
              public Lesson(string t, string t2, string r)
                  : this(t, t2, r, null, null)
              {
              }
      
      
              public Lesson(string t, string t2, string r, string b)
                  : this(t, t2, r, b, null)
              {
              }
              public Lesson(string t, string t2, string r, string b, string e)
              {
                  topic = t??"math";
                  teacher = t2??"mandelbrot";
                  room = r??"E215";
                  begin = b??"08:00";
                  end = e??"09:00";
      
              }
      
          }
