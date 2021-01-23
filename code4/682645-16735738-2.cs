    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.Phone.Controls;
    using ShakeGestures;
    using Windows.Phone.Media.Capture;
    
    namespace ShakerTorch
    {
        public partial class MainPage : PhoneApplicationPage
        {
            #region Initialisation
    
            private AudioVideoCaptureDevice _captureDevice;
            private bool _flashOn;
            private const CameraSensorLocation _sensorLocation = CameraSensorLocation.Back;
    
            public MainPage()
            {
                InitializeComponent();
                ShakeGesturesHelper.Instance.ShakeGesture += OnShake;
                ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 5;
                ShakeGesturesHelper.Instance.Active = true;
                InitialiseCaptureDevice();
            }
    
            #endregion
    
            private async void InitialiseCaptureDevice()
            {
                _captureDevice = await GetCaptureDevice();
            }
    
            private void OnShake(object sender, ShakeGestureEventArgs e)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        switch (e.ShakeType)
                        {
                            case ShakeType.X:
                                {
                                    _shakeStatusTextBlock.Text = string.Format("Left and right ({0})", e.ShakeType);
                                    _shakeStatusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                }
                            case ShakeType.Y:
                                {
                                    _shakeStatusTextBlock.Text = string.Format("Forward and backwards ({0})", e.ShakeType);
                                    _shakeStatusTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                }
                            case ShakeType.Z:
                                {
                                    _shakeStatusTextBlock.Text = string.Format("Up and down ({0})", e.ShakeType);
                                    _shakeStatusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                }
                        }
                        ToggleFlash();
                    });
            }
    
            private void ToggleFlash()
            {
                try
                {
                    IReadOnlyList<object> supportedCameraModes =
                        AudioVideoCaptureDevice.GetSupportedPropertyValues(_sensorLocation,
                                                                           KnownCameraAudioVideoProperties.VideoTorchMode);
    //ToDo Don't like this line. Simplify....
                    if (supportedCameraModes.ToList().Contains((UInt32) VideoTorchMode.On))
                    {
                        if (!_flashOn)
                        {
                            _captureDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.On);
                            _captureDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchPower,
                                                       AudioVideoCaptureDevice.GetSupportedPropertyRange(_sensorLocation,
                                                                                                         KnownCameraAudioVideoProperties
                                                                                                             .VideoTorchPower)
                                                                              .Max);
                            _contentGrid.Background = new SolidColorBrush(Colors.White);
                            _flashOn = true;
                        }
                        else
                        {
                            _captureDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.Off);
                            _contentGrid.Background = null;
                            _flashOn = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _shakeStatusTextBlock.Text = "The flash cannot be controlled on this device.";
                }
            }
    
            private async Task<AudioVideoCaptureDevice> GetCaptureDevice()
            {
                AudioVideoCaptureDevice captureDevice =
                    await
                    AudioVideoCaptureDevice.OpenAsync(_sensorLocation,
                                                      AudioVideoCaptureDevice.GetAvailableCaptureResolutions(_sensorLocation)
                                                                             .First());
                return captureDevice;
            }
        }
    }
