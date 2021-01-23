	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;
	public class Zone
	{
		public Region Region { get; private set; }
		public Action<MouseEventArgs> Click { get; private set; }
		public Zone(Region zoneRegion, Action<MouseEventArgs> click)
		{
			this.Region = zoneRegion;
			this.Click = click;
		}
	}
	public class PictureBoxWithClickableZones : PictureBox
	{
		private readonly List<Zone> zones = new List<Zone>();
		public void AddZone(Zone zone)
		{
			if (zone == null)
				throw new ArgumentNullException("zone");
			this.zones.Add(zone);
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			foreach (var zone in this.zones.Where(zone => zone.Region.IsVisible(e.Location)))
				zone.Click(e);
		}
	}
