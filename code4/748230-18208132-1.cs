    <object id="weeklyCalendar" type="My.Package.TaskExecutorDemo.WeeklyCalendarFactoryObject, TaskExecutorDemo">
      <property name="DaysOfWeekExcluded">
        <object type="System.Collections.Generic.HashSet&lt;System.DayOfWeek>">
          <constructor-arg name="collection" type="System.Collections.Generic.IEnumerable&lt;System.DayOfWeek>">
            <list element-type="System.DayOfWeek">
              <value>Friday</value>
              <value>Saturday</value>
              <value>Sunday</value>
            </list>
          </constructor-arg>
        </object>
      </property>
    </object>
