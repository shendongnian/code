	using System;
	using Twitterizer;
	using Twitterizer.Streaming;
	using System.Collections.Generic;
	 
	namespace StreamingAPIExample
	{
		class Program
		{
			static bool jsonView = false;
	 
			static OAuthTokens tokens = new OAuthTokens()
			{
				ConsumerKey = "REMOVED",
				ConsumerSecret = "REMOVED",
				AccessToken = "REMOVED",
				AccessTokenSecret = "REMOVED"
			};
	 
			static void Main(string[] args)
			{
				Console.BufferWidth = 100;
				Console.WindowWidth = 100;
	 
				StreamOptions options = new StreamOptions();
				options.Track.Add("#tallycc");
				options.Track.Add("tallycc");
				options.Track.Add("#tallycodecamp");
				options.Track.Add("tallycodecamp");
	 
				TwitterStream stream = new TwitterStream(
					tokens,
					"Tallahassee CodeCamp2001 Example Application",
					options);
	 
				Console.WriteLine("The stream is starting ...");
				stream.StartUserStream(
					StreamInit, 
					StreamStopped, 
					NewTweet, 
					DeletedTweet, 
					NewDirectMessage, 
					DeletedDirectMessage, 
					OtherEvent, 
					RawJson); //optional
	 
				Console.WriteLine("The stream has started. Press any key to stop.");
				Console.ReadKey();
	 
				Console.WriteLine("Stopping the stream ...");
				stream.EndStream(StopReasons.StoppedByRequest, "I'm stopping the stream.");
	 
				Console.WriteLine("Press any key to exit.");
				Console.ReadKey();
			}
	 
			static void StreamInit(TwitterIdCollection friends)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("{0} friends reported.", friends.Count));
			}
	 
			static void StreamStopped(StopReasons reason)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("The stream has stopped. Reason: {0}", reason.ToString()));
			}
	 
			static void NewTweet(TwitterStatus tweet)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("New tweet: @{0}: {1}", tweet.User.ScreenName, tweet.Text));
			}
	 
			static void DeletedTweet(TwitterStreamDeletedEvent e)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("Deleted tweet: Id: {0}; UserId: {1}", e.Id, e.UserId));
			}
	 
			static void NewDirectMessage(TwitterDirectMessage message)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("New message from {0}", message.SenderScreenName));
			}
	 
			static void DeletedDirectMessage(TwitterStreamDeletedEvent e)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("Deleted message: {0}", e.UserId));
			}
	 
			static void OtherEvent(TwitterStreamEvent e)
			{
				if (!jsonView)
					Console.WriteLine(string.Format("Other event. Type: {0}; From: {1}; {2}", e.EventType, e.Source.ScreenName, e.TargetObject));
			}
	 
			static void RawJson(string json)
			{
				if (jsonView)
					Console.WriteLine(json);
			}
		}
	}
