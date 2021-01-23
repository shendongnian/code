	namespace Example.ActualApp
	{
		using System;
		using System.Collections.Generic;
		/// <summary>
		/// The Program
		/// </summary>
		internal class Program
		{
			/// <summary>
			/// The main entry point.
			/// </summary>
			static void Main(string[] args)
			{
				// Create a new house with a bedroom
				Room bedroom1 = new Room("Master bedroom");
				House sampleHouse = new House("My house", bedroom1);
				
				// Add a room
				Room sittingRoom = new Room("Main sitting room");
				sampleHouse.AddRoom(sittingRoom);
				// Wait for user to press a button
				Console.WriteLine("\r\nFinished, press a key to end.");
				Console.ReadKey();
				return;
			}
		}
		/// <summary>
		/// House class
		/// </summary>
		internal class House
		{
			// Private fields
			private readonly string _name = string.Empty;
			private List<Room> _rooms = null;
			/// <summary>
			/// Initializes a new instance of the <see cref="House"/> class.
			/// </summary>
			/// <param name="name">The name of the house.</param>
			/// <param name="room">The default room.</param>
			public House(string name, Room room)
			{
				// Store the house name and initialise the rooms collection
				_name = name;
				_rooms = new List<Room>();
				Console.WriteLine("New house created called '{0}'", name);
				// Now add the default room
				this.AddRoom(room);
			}
			/// <summary>
			/// Adds a room to the house.
			/// </summary>
			/// <param name="room">The room.</param>
			public void AddRoom(Room room)
			{
				_rooms.Add(room);
				Console.WriteLine("Room called '{0}' added to house called '{1}'", room.Name, _name);
			}
		}
		/// <summary>
		/// Room class
		/// </summary>
		internal class Room
		{
			private string _roomName = string.Empty;
			/// <summary>
			/// Initializes a new instance of the <see cref="Room"/> class.
			/// </summary>
			/// <param name="name">The name of the room.</param>
			public Room (string name)
			{
				_roomName = name;
				Console.WriteLine("New room created called '{0}'", name);
			}
			/// <summary>
			/// Example property (never pass fields around)
			/// </summary>
			public string Name
			{
				get
				{
					return _roomName;
				}
				set
				{
					_roomName = value;
				}
			}
		}
	 }
