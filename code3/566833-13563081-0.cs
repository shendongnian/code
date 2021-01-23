    private PendingIntent service = null;  
		public override void OnUpdate (Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
		{
            //// To prevent any ANR timeouts, we perform the update in a service
            //context.StartService (new Intent (context, typeof (UpdateService)));
            AlarmManager m = (AlarmManager) context.GetSystemService(Context.AlarmService);
           Intent i = new Intent (context, typeof (UpdateService));
           if (service == null)
           {
               service = PendingIntent.GetService(context, 0, i, PendingIntentFlags.CancelCurrent);
           }
           m.SetRepeating(AlarmType.Rtc, 0, 1000 * 3, service);
		}
