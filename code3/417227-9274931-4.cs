          class OutPutter
          {
              private static int[] maxlength = new int[7];
              public static Lesson[][] timetable = new Lesson[7][];
      
              public OutPutter()
                  : this(null)
              {
              }
      
              public OutPutter(Lesson[][] tt)
              {
                  for (int i = 0; i < 7; i++)
                  {
                      maxlength[i] = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames.ElementAt(i).Length;
                      timetable[i] = ((tt == null || tt[i] == null) ? new Lesson[24] : tt[i]);
                  } 
              }
                                                                            
      
              public void add(int day, int hour, Lesson lesson)
              {
                  day -= 1;
                  timetable[day][hour]=lesson;
                  int currentLongest = maxlength[day];
                  if (lesson.begin.Length > currentLongest)
                      currentLongest = lesson.begin.Length;
                  if (lesson.end.Length > currentLongest)
                      currentLongest = lesson.end.Length;
                  if (lesson.teacher.Length > currentLongest)
                      currentLongest = lesson.teacher.Length;
                  if (lesson.topic.Length > currentLongest)
                      currentLongest = lesson.topic.Length;
                  if (lesson.room.Length > currentLongest)
                      currentLongest = lesson.room.Length;
                  if (currentLongest != maxlength[day])
                      maxlength[day] = currentLongest;
              }
      
              private static Lesson getLesson(int i2, int i)
              {
                  try 
                  {
                      return timetable[i][i2] ?? new Lesson("", "", "", "", "");
                  }
                  catch 
                  {
                      return new Lesson("", "", "", "", "");
                  }
              }
      
              public override string ToString()
              {
                  StringBuilder sb = new StringBuilder();
                  int maxLessons = 0;
                  foreach (Lesson[] current in timetable)
                  {
                      if (current.Length > maxLessons)
                          maxLessons = current.Length;
                  }
                  int lineLength = 1;
                  List<string> formatstrings = new List<string>();
                  for (int i = 0; i < 7; i++)
                  {
                      formatstrings.Add(" {0,"+maxlength[i].ToString()+"}");
                      sb.Append("|");
                      sb.AppendFormat(formatstrings.ElementAt(i), System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames.ElementAt(i));
                      lineLength += maxlength[i] + 2;
                  }
                  sb.Append("|");
                  sb.AppendLine();
                  sb.Append("".PadLeft(lineLength, '='));
                  for (int i2 = 0; i2 < maxLessons; i2++)
                  {
                      sb.AppendLine();
                      for (int i = 0; i < 7; i++)
                      {
                          sb.Append("|");
                          sb.AppendFormat(formatstrings.ElementAt(i), getLesson(i2, i).topic);
                      }
                      sb.Append("|");
                      sb.AppendLine();
                      for (int i = 0; i < 7; i++)
                      {
                          sb.Append("|");
                          sb.AppendFormat(formatstrings.ElementAt(i), getLesson(i2, i).teacher);
                      }
                      sb.Append("|");
                      sb.AppendLine();
                      for (int i = 0; i < 7; i++)
                      {
                          sb.Append("|");
                          sb.AppendFormat(formatstrings.ElementAt(i), getLesson(i2, i).room);
                      }
                      sb.Append("|");
                      sb.AppendLine();
                      for (int i = 0; i < 7; i++)
                      {
                          sb.Append("|");
                          sb.AppendFormat(formatstrings.ElementAt(i), getLesson(i2, i).begin);
                      }
                      sb.Append("|");
                      sb.AppendLine();
                      for (int i = 0; i < 7; i++)
                      {
                          sb.Append("|");
                          sb.AppendFormat(formatstrings.ElementAt(i), getLesson(i2, i).end);
                      }
                      sb.Append("|");
                      sb.AppendLine();
                      sb.Append("".PadLeft(lineLength, '-'));
                  }
                  return sb.ToString();
              }
      
          }
