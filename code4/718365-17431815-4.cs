    using System;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    namespace So17371439ItemsLayoutBounty
    {
        public partial class MainWindow
        {
            public ObservableCollection<PreferenceGroup> PreferenceGroups { get; private set; }
            public MainWindow ()
            {
                var rnd = new Random();
                PreferenceGroups = new ObservableCollection<PreferenceGroup>();
                for (int i = 0; i < 100000; i++) {
                    var group = new PreferenceGroup { Name = string.Format("Group {0}", i), SelectionMode = rnd.Next(1, 4) };
                    int nprefs = rnd.Next(5, 40);
                    for (int j = 0; j < nprefs; j++)
                        group.Preferences.Add(new Preference { Name = string.Format("Pref {0}", j), Quantity = rnd.Next(100) });
                    PreferenceGroups.Add(group);
                }
                InitializeComponent();
            }
        }
        public class PreferenceGroup
        {
            public string Name { get; set; }
            public int SelectionMode { get; set; }
            public ObservableCollection<Preference> Preferences { get; private set; }
            public PreferenceGroup ()
            {
                Preferences = new ObservableCollection<Preference>();
            }
        }
        public class Preference
        {
            public string Name { get; set; }
            public string GroupId { get; set; }
            public int Quantity { get; set; }
        }
        public static class PixelBasedScrollingBehavior
        {
            public static bool GetIsEnabled (DependencyObject obj)
            {
                return (bool)obj.GetValue(IsEnabledProperty);
            }
            public static void SetIsEnabled (DependencyObject obj, bool value)
            {
                obj.SetValue(IsEnabledProperty, value);
            }
            public static readonly DependencyProperty IsEnabledProperty =
                DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(PixelBasedScrollingBehavior),
                    new UIPropertyMetadata(false, IsEnabledChanged));
            private static void IsEnabledChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var isEnabled = (bool)e.NewValue;
                if (d is VirtualizingPanel) {
                    if (TrySetScrollUnit(d, isEnabled))
                        return;
                    if (!TrySetIsPixelBased(d, isEnabled))
                        throw new InvalidOperationException("Failed to set IsPixelBased or ScrollUnit property.");
                }
                if (d is ItemsControl) {
                    TrySetScrollUnit(d, isEnabled);
                }
            }
            private static bool TrySetScrollUnit (DependencyObject ctl, bool isEnabled)
            {
                // .NET 4.5: ctl.SetValue(VirtualizingPanel.ScrollUnitProperty, isEnabled ? ScrollUnit.Pixel : ScrollUnit.Item);
                var propScrollUnit = typeof(VirtualizingPanel).GetField("ScrollUnitProperty", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                if (propScrollUnit == null)
                    return false;
                var dpScrollUnit = (DependencyProperty)propScrollUnit.GetValue(null);
                var assemblyPresentationFramework = typeof(Window).Assembly;
                var typeScrollUnit = assemblyPresentationFramework.GetType("System.Windows.Controls.ScrollUnit");
                if (typeScrollUnit == null)
                    return false;
                var valueScrollUnit = Enum.Parse(typeScrollUnit, isEnabled ? "Pixel" : "Item");
                ctl.SetValue(dpScrollUnit, valueScrollUnit);
                return true;
            }
            private static bool TrySetIsPixelBased (DependencyObject ctl, bool isEnabled)
            {
                // .NET 4.0: ctl.IsPixelBased = isEnabled;
                var propIsPixelBased = ctl.GetType().GetProperty("IsPixelBased", BindingFlags.NonPublic | BindingFlags.Instance);
                if (propIsPixelBased == null)
                    return false;
                propIsPixelBased.SetValue(ctl, isEnabled, null);
                return true;
            }
        }
    }
